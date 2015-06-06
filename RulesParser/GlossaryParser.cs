using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesParser
{	
	static class GlossaryParser
	{

		//This returns a Dictionary, where the key is the term we're defining
		//and the value is a list of all the different definitions.
		//This assumes that each term/definition pair is seperated by an empty line.
		public static Dictionary<string, List<string>> GetGlossary(string glossaryLocation = @".\text\glossary.txt")
		{

			string glossaryText = System.IO.File.ReadAllText(glossaryLocation);
			var parsedGlossary = glossaryText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
			var glossary = new Dictionary<string, List<string>>();
			//Regex.Split(glossaryText, Environment.NewLine);

			var currentTerm = string.Empty;
			foreach (var line in parsedGlossary)
			{
				if (line == string.Empty) //Empty line means we're moving on to a new term
				{
					currentTerm = string.Empty;
					continue;
				}

				//a non-empty line after an empty line means that the non-empty line is our new term
				if (currentTerm == string.Empty)
				{
					currentTerm = line;
					glossary.Add(currentTerm, new List<string>());
					continue;
				}

				//if the line isn't empty, and we know which term we're looking at, the line must be
				//a definition. Add it to that terms definition list.
				glossary[currentTerm].Add(line);
			}

			return glossary;
		}

		public static void PrintGlossary(Dictionary<string, List<string>> glossary)
		{
			foreach (var entry in glossary)
			{
				Console.WriteLine(entry.Key);
				foreach (var definition in entry.Value)
				{
					Console.WriteLine("\t" + definition);
				}
				Console.WriteLine("");
			}
		}
	}
}
