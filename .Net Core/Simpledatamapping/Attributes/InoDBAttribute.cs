using System;

namespace Simpledatamapping.Attributes
{
    public class InoTableAttribute : Attribute
    {

    }
    public class InoFieldAttribute : Attribute
    {
        public InoFieldAttribute() { }
        public InoFieldAttribute(string bindName)
        {
            this.BindName = bindName;
        }
        public string BindName { get; set; }
    }
}