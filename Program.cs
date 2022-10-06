// 2022-09-29; CS 1400; Lab 4
using System.Linq;


// Calculate yearly salary from inputted values
decimal yearlySalary(decimal hourlyWage, int hoursPerWeek, int weeksPerYear) {

	decimal yearlySalaryValue = 0M;
	yearlySalaryValue = ((decimal)hoursPerWeek * (decimal)weeksPerYear) * hourlyWage;

	return yearlySalaryValue;
}

// Rectify generated integer wages into decimal values
decimal rectifyWage(int integerWage){

	decimal rectifiedWage = 0.0M;
	rectifiedWage = (decimal)integerWage / 100.00M;

	return rectifiedWage;
}

int numberOfPeople = 1000;
int wageLowerBound = 725;
int wageUpperBound = 4000;
int hoursPerWeek = 40;
int weeksPerYear = 50;

// Generate integer wages and store in array
int[] integerWages = new int[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	int generatedWage = 0;

	Random rnd = new Random();
	generatedWage = rnd.Next(wageLowerBound, wageUpperBound);

	integerWages[i] = generatedWage;
}

// Rectify integers wages and store in array
decimal[] rectifiedWages = new decimal[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	decimal hourlyWage = 0.0M;
	hourlyWage = rectifyWage(integerWages[i]);
	rectifiedWages[i] = hourlyWage;
}

// Calculate yearly salaries and store in array
decimal[] yearlySalaries = new decimal[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	decimal yearlySalaryValue = 0.0M;
	yearlySalaryValue = yearlySalary(rectifiedWages[i], hoursPerWeek, weeksPerYear);
	yearlySalaries[i] = yearlySalaryValue;
}


// --------------------------------------------------------------


// Generate array of CV pairs from lists of consonants and vowels
string[] consonants = new string[] {

	"b", "ch", "d", "f", "g", "h", "k", "l", "m", "n", "\u00F1", "ng", "'", "p", "r", "s", "t", "y",
};

string[] vowels = new string[] {

	"a", "\u00E5", "e", "i", "o", "u",
};

// Dynamically find the needed array length
int pairsLength = consonants.Length * vowels.Length;
string[] pairsCV = new string[pairsLength];

// For each consonant, loop through each vowel and combine
int pairIndex = 0;
for (int i = 0; i < consonants.Length; i++) {

	string combined = "";

	foreach (string vowel in vowels) {
		combined = consonants[i] + vowel;
		pairsCV[pairIndex] = combined;
		pairIndex += 1;
	}
}


// --------------------------------------------------------------


// Generate array of names / CV-pair combinations
int namesLength = pairsLength * pairsLength;
string[] namesArray = new string[namesLength];

int nameIndex = 0;
for (int i = 0; i < pairsCV.Length; i++) {

	string combined = "";

	foreach (string nameBeta in pairsCV) {

		combined = pairsCV[i] + nameBeta;

			if (combined == " ") {
				break;
			}

		namesArray[nameIndex] = combined;
		nameIndex += 1;

	}
}


// --------------------------------------------------------------


// Pseudorandom |-> Pseudo + (r)andom |-> Pseudor --> "Suitor"; ∴ Pseudorandom --> Suitor
// I'm hilarious
Random suitor = new Random(); 

int rnJesus(int lowerBound, int upperBound) {
	int index = suitor.Next(lowerBound, upperBound);
	return index;
}

// Select 1,000 random names by generating unique, pseudorandom index values
int[] uniqueIndices = new int[numberOfPeople];

// Fill array with random, unique indices
for (int i = 0; i < 1000; i++) {

	Retry:
	int generatedIndex = suitor.Next(0, namesArray.Length-1);
	switch (uniqueIndices.Contains(generatedIndex)) {

		case true:
			goto Retry;

		case false:
			uniqueIndices[i] = generatedIndex;
			break;
	}
}

// Fill array with the respective name for each index
string[] selectedNames = new string[numberOfPeople];

for (int i = 0; i < 1000; i++) {
	string indexedName;
	int index = 0;

	index = uniqueIndices[i];
	indexedName = namesArray[index];
	selectedNames[i] = indexedName;

	// Console.WriteLine($"[{index}]: {indexedName}");
}


// --------------------------------------------------------------


// Generate job titles from adjectives and agent nouns
string[] jobAdjectives = new string[] {
	"Average", "Awful", "Bad", "Better", "Bewildered", "Bored", 
	"Brave", "Busy", "Careful", "Cheerful", "Clever", "Clumsy", 
	"Concerned", "Condemned", "Curious", "Dangerous", "Defiant", 
	"Distinct", "Doubtful", "Eager", "Energetic", "Evil", "Fancy", 
	"Foolish", "Fragile", "Frantic", "Gifted", "Horrible", "Inquisitive", 
	"Jittery", "Lively", "Mysterious", "Nervous", "Odd", "Old-Fashioned", 
	"Perfect", "Plain", "Powerful", "Puzzled", "Relieved", "Sore", 
	"Splendid", "Strange", "Talented", "Terrible", "Tired", "Troubled", 
	"Uptight", "Weary", "Worried", "Wrong",
};

string[] jobAgentNouns = new string[] {
	"Abolisher", "Advertiser", "Anesthetizer", "Arguer", "Axe Murderer", 
	"Bagger", "Baker", "Bootlegger", "Buyer", "Campaigner", "Cheater", 
	"Choreographer", "Climber", "Collector", "Creator", "Dancer", 
	"Defender", "Designer", "Destroyer", "Digger", "Diver", "Emancipator", 
	"Engineerer", "Entertainer", "Fascilitator", "Farmer", "Fixer", 
	"Gatherer", "Governor", "Grader", "Healer", "Helper", "Impeacher", 
	"Improviser", "Inquirer", "Interrogator", "Inventor", "Jailer", 
	"Juggler", "Kayaker", "Leader", "Lockpicker", "Negotiator", "Pacifier", 
	"Patroller", "Performer", "Pillager", "Planner", "Planter", "Plunderer", 
	"Poller", "Programmer", "Pronouncer", "Protector", "Reader", "Recorder", 
	"Recycler", "Refiner", "Reformer", "Runner", "Salvager", "Scavenger", 
	"Seeder", "Seller", "Shepherder", "Singer", "Sleeper", "Smuggler", 
	"Stealer", "Swindler", "Talker", "Teacher", "Terraformer", "Tester", 
	"Trader", "Unifier", "Upseller", "Vetter", "Waterer",
};

string[] jobTitles = new string[numberOfPeople];

for (int i = 0; i < numberOfPeople; i++) {

	string combined = "";
	string adjective = jobAdjectives[rnJesus(0, jobAdjectives.Length-1)];
	string agentNoun = jobAgentNouns[rnJesus(0, jobAgentNouns.Length-1)];

	combined = $"{adjective} {agentNoun}";
	jobTitles[i] = combined;

}


// -------------------------------------------------------------------------------


// Output Printing
Console.Clear();
for (int i = 0; i < numberOfPeople; i++) {

	int characterCount = 0;
	string justify = "";

	// Justify printed output based on name length
	foreach (char letter in selectedNames[i]) {
		characterCount += 1;
	}

	if (characterCount == 4) {
		justify = "  ";
	}
	else if (characterCount == 5) {
		justify = " ";
	}
	else {
		justify = "";
	}

	Console.WriteLine($"{selectedNames[i]}: {justify} ${rectifiedWages[i]:00.00}/hr = ${yearlySalaries[i]:0,0.00}/yr | {jobTitles[i]}");
}


// -------------------------------------------------------------------------------

// Note: `Snippet.Break()` is a custom method I created to insert a blank line.
// Snippet.cs will be added to as I create more snippets.

// Addendum Error Log
Snippet.Break();
Console.WriteLine("|[ Error Log ]|");
Snippet.Break();

Console.WriteLine("Duplicate Name Check:");
for (int i = 0; i < selectedNames.Length; i++) {
	string errorFlag = "[Duplicate Name Found]";
	string nameAlpha = selectedNames[i];

	for (int j = 0; j < selectedNames.Length; j++) {
		string nameBeta = selectedNames[j];	

		if (j == i) { // Skip the current, primary name
			break;
		}
		else if (nameAlpha == nameBeta) {

			Console.WriteLine($"{errorFlag} : [{i}]{nameAlpha} and [{j}]{nameBeta}");
		}
	}
}

Snippet.Break();

Console.WriteLine("Out-of-Bound Wage Check:");
foreach (int wage in integerWages) {

	string errorFlag = "";
	if (wage < wageLowerBound || wage > wageUpperBound) {
		errorFlag = "[Wage Out of Bounds]";
		Console.WriteLine($"{errorFlag} : {wage}");
	}
}

Snippet.Break();
Console.ReadKey();