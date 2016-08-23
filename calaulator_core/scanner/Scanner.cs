﻿using System;
using System.Collections;
using System.IO;
using System.Text;

namespace calaulator_core.scanner
{
    public class Scanner
    {
        public static int line = 1;
        char peek = ' ';
        Hashtable words;
        StringReader reader;
        public Scanner(StringReader reader)
        {
            words = new Hashtable();

            reserve(Word.True);
            reserve(Word.False);
            this.reader = reader;
        }
        void reserve(Word w)
        {
            words.Add(w.lex, w);
        }
        void next()
        {
            peek = (char)reader.Read();
        }
        Boolean next(char c)
        {
            next();
            if (peek != c)
                return false;
            peek = ' ';
            return true;
        }
        public Token scan()
        {
            for (; ; next())
            {
                if (peek == ' ' || peek == '\t' || peek == '\r') continue;
                else if (peek == '\n') line = line + 1;
                // int -1 转换为char 后的值
                else if (peek == 65535) return null;
                break;
            }
            switch (peek)
            {
                case '&':
                    if (next('&')) return Word.and; else return new Token('&');
                case '|':
                    if (next('|')) return Word.or; else return new Token('|');
                case '=':
                    if (next('=')) return Word.eq; else return new Token('=');
                case '!':
                    if (next('=')) return Word.ne; else return new Token('!');
                case '<':
                    if (next('=')) return Word.le; else return new Token('<');
                case '>':
                    if (next('=')) return Word.ge; else return new Token('>');
            }
            if (char.IsDigit(peek))
            {
                StringBuilder b = new StringBuilder(32);
                do
                {
                    b.Append(peek);
                    next();
                } while (char.IsDigit(peek));
                if (peek != '.')
                    return new Num(int.Parse(b.ToString()));
                b.Append('.');
                while (true)
                {
                    next();
                    if (!char.IsDigit(peek)) break;
                    b.Append(peek);
                }
                return new Real(double.Parse(b.ToString()));
            }
            if (char.IsLetter(peek) || peek == '_')
            {
                StringBuilder b = new StringBuilder(32);
                do
                {
                    b.Append(peek);
                    next();
                } while (char.IsLetterOrDigit(peek));
                string s = b.ToString();
                Word w = (Word)words[s];
                if (w != null) return w;
                w = new Word(s, Tag.ID);
                words.Add(s, w);
                return w;
            }
            Token tok = new Token(peek);
            peek = ' ';
            return tok;
        }
    }
}