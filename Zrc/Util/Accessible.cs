namespace Zrc.Util
{
    public enum Privacy
    {
        Public,
        Private,
        Protected,
        Internal
    }

    public enum Locality
    {
        Local,
        Static
    }
    public class Accessible<T>
    {
        public Privacy Privacy { get; private set; }
        public Locality Locality { get; private set; }
        public T Member { get; private set; }

        public Accessible(Privacy privacy, Locality locality, T member)
        {
            Privacy = privacy;
            Locality = locality;
            Member = member;
        }
    }
}