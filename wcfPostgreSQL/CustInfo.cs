using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcfPostgreSQL
{
    internal class CustInfo
    {
        protected int CustId {  get; set; }
        protected string Name { get; set;}
        protected string Company {  get; set; }
        public CustInfo() { }
        public CustInfo(int Id, string name, string company)
        {
            CustId = Id;
            Name = name;
            Company = company;
        }
    }
}
