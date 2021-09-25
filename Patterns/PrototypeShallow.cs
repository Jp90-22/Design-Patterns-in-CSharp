using System;

namespace Design_Patterns.Patterns
{
    // Shallow form of Prototype or Conation
    public class PrototypeShallow : ICloneable
    {
        public int ID { get; set; }
        public string Attr1 { get; set; }
        public string Attr2 { get; set; }

        public PrototypeShallow(int iD, string attr1, string attr2)
        {
            ID = iD;
            Attr1 = attr1;
            Attr2 = attr2;

            Console.WriteLine(
                $"-> Instace created at: {nameof(PrototypeShallow)} constructor\n" +
                $"\tWith attributes: Id: {iD}, {Attr1}, {Attr2}"
            );
        }

        public object Clone() => this.MemberwiseClone();
    }
}