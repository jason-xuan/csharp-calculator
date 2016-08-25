using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using calaulator_core.scanner;

namespace calaulator_core.parser
{
    /// <summary>
    /// 
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// parser 通过 scanner 将字符串截取为一个一个的Token，再以流的形式读取
        /// </summary>
        private Scanner scanner;

        /// <summary>
        /// 下一个Token，向前看1位
        /// </summary>
        private Token peek;

        /// <summary>
        /// 下下个Token, 向前看2位
        /// </summary>
        private Token forhead;

        /// <summary>
        /// 构造时指定scanner，适用于仅parse一次的情况
        /// </summary>
        /// <param name="scanner">
        /// scanner 应配置好stream reader
        /// </param>
        public Parser(Scanner scanner)
        {
            this.scanner = scanner;
            forhead = new Token(Tag.START);
            next();
        }

        /// <summary>
        /// 无参构造，适用于重复parse的情况
        /// </summary>
        public Parser()
        {
            scanner = new Scanner();
        }

        /// <summary>
        /// 重新设置 peek 和 forhead 的值，指针指向下一个token
        /// </summary>
        private void next()
        {
            peek = forhead;
            forhead = scanner.scan();
        }

        private void error(string e)
        {
            throw new SyntaxError(e);
        }

        /// <summary>
        /// 当某状态只有一个输出时，确认是否有语法错误
        /// </summary>
        /// <param name="t">
        /// 待确认Tag
        /// </param>
        private void match(Tag t)
        {
            if (peek.Tag == t)
            {
                next();
            }
            else
            {
                error("syntax error");
            }
        }

        /// <summary>
        /// 免去调用时显式转换的重载函数
        /// </summary>
        /// <param name="v">
        /// 待确认Tag
        /// </param>
        private void match(char v)
        {
            match((Tag)v);
        }

        /// <summary>
        /// parse的入口函数
        /// </summary>
        /// <returns>
        /// 返回语法树的根节点
        /// </returns>
        public Node Parse()
        {
            match(Tag.START);
            var exp = expression();
            return exp;
        }

        /// <summary>
        /// 多次调用parse时的方法，重新设置stream reader
        /// </summary>
        /// <param name="text">
        /// 待计算表达式
        /// </param>
        /// <returns>
        /// 返回语法树的根节点
        /// </returns>
        public Node Parse(string text)
        {
            StringReader reader = new StringReader(text);
            scanner.ResetReader(reader);
            forhead = new Token(Tag.START);
            next();
            return Parse();
        }

        /// <summary>
        /// 普通的表达式，可能包含多重赋值
        /// 文法：
        /// expression -> ID = expression  | simple_expression
        /// </summary>
        /// <returns>
        /// expression 语法树的根节点
        /// </returns>
        private Node expression()
        {
            // 普通表达式
            if (peek.Tag != Tag.ID)
                return simple_expression();
            else
            {
                // 赋值语句，向前看两项（变量只有一项）
                if (forhead.Tag == (Tag)'=')
                {
                    Node left = new Identifier(peek.ToString());
                    next();
                    match('=');
                    Node right = simple_expression();
                    return new Assign(left, right);
                }
                {
                    return simple_expression();
                }
            }
        }

        /// <summary>
        /// 不含赋值的普通表达式
        /// 文法：
        /// simple_expression -> additive_expression { relop additive_expression}
        /// </summary>
        /// <returns>
        /// simple expression 语法树的根节点
        /// </returns>
        private Node simple_expression()
        {
            Node first = additive_expression();
            while (
                (peek.Tag == Tag.EQ) ||
                (peek.Tag == Tag.NE) ||
                (peek.Tag == Tag.GE) ||
                (peek.Tag == Tag.LE) ||
                (peek.Tag == (Tag)'>') ||
                (peek.Tag == (Tag)'<')
                )
            {
                Tag op = peek.Tag;
                next();
                Node second = additive_expression();
                return new Operation(first, op, second);
            }
            return first;
        }

        /// <summary>
        /// 不含逻辑运算的表达式
        /// 文法：
        /// additive_expression -> term {addop term}
        /// </summary>
        /// <returns>
        /// additive expression 语法树的根节点
        /// </returns>
        private Node additive_expression()
        {
            Node left = term();
            while (
                (peek.Tag == (Tag)'+') || 
                (peek.Tag == (Tag)'-')
                )
            {
                Tag op = peek.Tag;
                next();
                Node right = term();
                Node q = new Operation(left, op, right);
                left = q;
            }
            return left;
        }

        /// <summary>
        /// 一级运算因式
        /// 文法：
        /// term -> factor {mulop factor}
        /// </summary>
        /// <returns>
        /// term 语法树的根节点
        /// </returns>
        private Node term()
        {
            Node left = factor();
            while (
                (peek.Tag == (Tag)'*') ||
                (peek.Tag == (Tag)'/')
                )
            {
                Tag op = peek.Tag;
                next();
                Node right = factor();
                Node q = new Operation(left, op, right);
                left = q;
            }
            return left;
        }

        /// <summary>
        /// 因式
        /// 文法：
        /// factor -> cubexp {cubop cubexp}
        /// </summary>
        /// <returns>
        /// 因式表达式的根节点
        /// </returns>
        private Node factor()
        {
            Node left = cubexp();
            while (
                (peek.Tag == (Tag)'^')
                )
            {
                Tag op = peek.Tag;
                next();
                Node right = cubexp();
                Node q = new Operation(left, op, right);
                left = q;
            }
            return left;
        }

        /// <summary>
        /// 立方运算，优先级最高，故在递归的终点
        /// 文法：
        /// cubexp -> (expression) | ID | NUM  |call
        ///             括号表达式  变量 常数 函数调用
        /// </summary>
        /// <returns>
        /// 语法树的根节点
        /// </returns>
        private Node cubexp()
        {
            switch (peek.Tag)
            {
                // (expression)
                case (Tag)'(':
                    next();
                    Node expr = expression();
                    match(')');
                    return expr;
                // ID
                case Tag.ID:
                    if (SymbolTable.Table.ContainsKey(peek.ToString()))
                    {
                        double value;
                        value = ((Identifier)SymbolTable.Table[peek.ToString()]).Value;
                        next();
                        return new Variable(value);
                    }
                    else
                    {
                        throw new SyntaxError("variable is not exist.");
                    }
                case Tag.Pi:
                    next();
                    return new Variable(Math.PI);
                case Tag.e:
                    next();
                    return new Variable(Math.E);
                case Tag.SIN:
                case Tag.COS:
                case Tag.TAN:
                case Tag.LN:
                case Tag.LOG:
                    return call();
                case Tag.NUM:
                    Node node = new Variable(((Num)peek).Value);
                    next();
                    return node;
                case Tag.REAL:
                    Node node2 = new Variable(((Real)peek).Value);
                    next();
                    return node2;
            }
            throw new SyntaxError("syntax error.");
        }
        
        /// <summary>
        /// 函数调用
        /// 文法:
        /// call -> func ( expression )
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        private Node call()
        {
            Tag func = peek.Tag;
            next();
            match('(');
            Node expr = expression();
            match(')');
            return new Function(func, expr);
        }
    }
}
