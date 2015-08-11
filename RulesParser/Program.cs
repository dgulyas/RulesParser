namespace RulesParser
{
	class Program
	{
		static void Main(string[] args)
		{
			RuleParser.ParseRules();
			RuleParser.testGetRuleLineType();

			//var glos = GlossaryParser.GetGlossary();
			//GlossaryParser.PrintGlossary(glos);

		}
	}
}
