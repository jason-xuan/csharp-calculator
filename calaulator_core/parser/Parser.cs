using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using calaulator_core.scanner;

namespace calaulator_core.parser
{
    public class Parser
    {
        private Scanner scanner;
        private Token peek;
        private Token forhead;
        public Parser(Scanner scanner)
        {
            this.scanner = scanner;
            forhead = new Token(Tag.START);
            next();
        }
        public Parser()
        {
            scanner = new Scanner();
        }
        private void next()
        {
            peek = forhead;
            forhead = scanner.scan();
        }
        private void error(string e)
        {
            throw new SyntaxError(e);
        }
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
        public Node Parse(string text)
        {
            StringReader reader = new StringReader(text);
            scanner.ResetReader(reader);
            forhead = new Token(Tag.START);
            next();
            return Parse();
        }
        private Node expression()
        {
            Node exp;
            if (peek.Tag != Tag.ID)
                return simple_expression();
            else
            {
                // 赋值语句
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
    }
}
