﻿// 2022-09-29; CS 1400; Lab 4
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

	// Console.WriteLine($"${rectifiedWages[i]:0.00}");
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
Console.WriteLine($"nameLength = {namesLength}");
string[] namesArray = new string[namesLength];
Console.WriteLine($"namesArray = {namesArray.Length}");

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
bool indexGeneratorLoop = true;

// Fill array with random, unique indices
for (int i = 0; i < 1000; i++) {

Retry:
	int generatedIndex = suitor.Next(0, namesArray.Length-1);
	switch (uniqueIndices.Contains(generatedIndex)) {

		case true:
			goto Retry;
			break;

		case false:
			uniqueIndices[i] = generatedIndex;
			break;

		// green TODO: Create dedicated error section at the bottom
		default:
			goto Retry;
			break;
	}

	Console.WriteLine(generatedIndex);
}

// Fill array with the respective name for each index
string[] selectedNames = new string[];






// -------------------------------------------------------------------------------

// Output Printing
for (int i = 0; i < numberOfPeople; i++) {

	// Console.WriteLine($"${rectifiedWages[i]:00.00}/hr === ${yearlySalaries[i]:0.00}/yr");
}

// Addendum Error Log
Snippet.Break();
Console.WriteLine("|[ Error Log ]|");
Snippet.Break();

Console.WriteLine("|[ Unique Index Generation ]|");
string flagIndexDuplicate = "";
for (int i = 0; i < uniqueIndices.Length-1; i++) {

	foreach (int index in uniqueIndices) {
		flagIndexDuplicate = $"Duplicates: {index} and {uniqueIndices[i]}.";

		switch (index == uniqueIndices[i]) {

			case true:
				Console.WriteLine(flagIndexDuplicate);
				break;
			case false:
				continue;
				break;
			default:
				Console.WriteLine("[Boolean Switch Statement: Return Default Error]");
				break;
		}
	}
}

Snippet.Break();

foreach (int wage in integerWages) {

	string errorFlag = "";
	if (wage < wageLowerBound || wage > wageUpperBound) {
		errorFlag = "[Wage Out of Bounds]";
		Console.WriteLine($"{wage} {errorFlag}");
	}
}