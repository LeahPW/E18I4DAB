using System;

namespace TraderInfo.Controllers
{
    internal class ProducesAttribute : Attribute
    {
        private string v;

        public ProducesAttribute(string v)
        {
            this.v = v;
        }
    }
}