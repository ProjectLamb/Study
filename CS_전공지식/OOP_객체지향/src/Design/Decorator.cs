using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPattern
{
    public abstract class Item {
        public abstract int GetLineCount();
        public abstract int GetMaxLength();
        public abstract int GetLength(int i);
        public abstract String GetString(int _i);
        public virtual void PrintString() { 
            int lineNum = GetLineCount();
            for (int i = 0; i < lineNum; i++) {
                String str = GetString(i);
                Console.WriteLine(str);
            }
        }
    }

    public class Strings : Item {
        private List<String> strings = new List<String>();

        public void add(String _str) { 
            strings.Add(_str);
        }
        public override int GetLineCount() {
            return strings.Count();
        }
        public override int GetMaxLength() {
            int maxLen = 0;
            foreach (String E in strings) {
                maxLen = maxLen < E.Length ? E.Length : maxLen;
            }
            return maxLen;
        }
        public override int GetLength(int i) {
            return strings[i].Length;
        }
        public override String GetString(int i) {
            return strings[i];
        }
    }
    public abstract class Decorator : Item
    {
        protected Item item;
        public Decorator(Item item) {
            this.item = item;
        }
    }

    public class SideDecorator : Decorator {
        private readonly Char decoChar = ' ';
        public SideDecorator(Item item, Char _c) : base(item){
            decoChar = _c;
        }
        public override int GetLineCount() {
            return item.GetLineCount();
        }
        public override int GetMaxLength() {
            return item.GetMaxLength() + 2;
        }
        public override int GetLength(int i) {
            return item.GetLength(i) + 2;
        }
        public override String GetString(int i) {
            return decoChar + item.GetString(i) + decoChar;
        }
    }
    public class BoxDecorator : Decorator {

        public BoxDecorator(Item item) : base(item) { }
        public override int GetLineCount() {
            return item.GetLineCount() + 2;
        }
        public override int GetMaxLength() {
            return item.GetMaxLength() + 2;
        }
        public override int GetLength(int i) {
            return item.GetLength(i) + 2;
        }
        public override String GetString(int i) {
            int maxLen = GetLineCount();
            if (i == 0 || i == maxLen-1) { return MakeBorder(); }
            return $"|{MakeTailString(item.GetString(i-1))}|";
        }
        String MakeBorder() {
            int maxLen = GetMaxLength();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < maxLen; i++) {
                if (i == 0 || i == maxLen - 1) { sb.Append('+'); continue; }
                sb.Append('-');
            }
            return sb.ToString();
        }
        string MakeTailString(string _target) {
            int maxLen = item.GetMaxLength();
            int spaceLen = maxLen - _target.Length;
            for (int i = 0; i < spaceLen; i++) { _target += ' '; }
            return _target;
        }
    }
    public class LineNumberDecorator : Decorator {

        public LineNumberDecorator(Item item) : base(item){ }
        public override int GetLineCount() {
            return item.GetLineCount();
        }
        public override int GetMaxLength() {
            return item.GetMaxLength() + 4;
        }
        public override int GetLength(int i) {
            return item.GetLength(i) + 4;
        }
        public override String GetString(int i) {
            return $"{String.Format("{0,2:D2}", i)} :{item.GetString(i)}";
        }
    }
    
    static void Main(string[] argv)
    {
        Strings strings = new Strings();
        strings.add("Hello~");
        strings.add("My name is escatrgot");
        strings.add("I am a Game and Web Developer");
        strings.add("Right now im learning DesignPattern !!");
        strings.PrintString();
        Item decorator = new SideDecorator(strings, '/');
        decorator = new BoxDecorator(decorator);
        decorator = new LineNumberDecorator(decorator);
        decorator = new BoxDecorator(decorator);
        decorator = new LineNumberDecorator(decorator);
        decorator.PrintString();
    }
}
