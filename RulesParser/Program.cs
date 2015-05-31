using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesParser
{
	class Program
	{
		static void Main(string[] args)
		{
			var g = GlossaryParser.GetGlossary();
			GlossaryParser.PrintGlossary(g);

			
		}
	}
}
