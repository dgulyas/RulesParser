using System;
using System.Diagnostics;
using System.IO;

namespace RulesParser
{
	static class RuleParser
	{
		public enum lineType { SectionLine, SubSectionLine, MainRuleLine, SubRuleLine, ExampleLine };

		public static void ParseRules(string glossaryLocation = @".\text\rules.txt")
		{
			string rulesText = File.ReadAllText(glossaryLocation);
			var parsedRules = rulesText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
			foreach (var line in parsedRules)
			{
				if (line == "")
				{
					continue;
				}

				int tokenRuleDivide = line.IndexOf(" ", StringComparison.Ordinal);
				var token = line.Substring(0, tokenRuleDivide);
				if (token == "")
				{
					return;
				}
				var typeOfLine = getRuleLineType(token);


			}

		}


		//assumes that token is always a valid token
		public static lineType? getRuleLineType(string token)
		{
			if (token.Length == 8)
			{
				return lineType.ExampleLine;
			}

			if (token.Length == 2)
			{
				return lineType.SectionLine;
			}

			if (token.Length == 4)
			{
				return lineType.SubSectionLine;
			}

			if (token.Length != 6)
			{
				return null;
			}

			if (token[5] == '.')
			{
				return lineType.MainRuleLine;
			}

			if (char.IsLetter(token[5]))
			{
				return lineType.SubRuleLine;
			}
			return null;

		}

		public static void testGetRuleLineType()
		{
			var testNumber = 0;
			Debug.Assert(getRuleLineType("1.") == lineType.SectionLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("9.") == lineType.SectionLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("100.") == lineType.SubSectionLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("109.") == lineType.SubSectionLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("100.1.") == lineType.MainRuleLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("401.7.") == lineType.MainRuleLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("405.6d") == lineType.SubRuleLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("508.1j") == lineType.SubRuleLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("Example:") == lineType.SectionLine, (++testNumber).ToString());
			Debug.Assert(getRuleLineType("...") == null, (++testNumber).ToString());
		}

	}
}
