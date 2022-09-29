// 2022-09-29; CS 1400; Lab 4

static decimal yearlySalary(decimal hourlyWage, int hoursPerWeek, int weeksPerYear) {

	decimal yearlySalaryValue = 0M;
	yearlySalaryValue = ((decimal)hoursPerWeek * (decimal)weeksPerYear) * hourlyWage;

	return yearlySalaryValue;
}

static decimal rectifyWage(int integerWage){

	decimal rectifiedWage = 0.0M;
	rectifiedWage = (decimal)integerWage / 100.00M;

	return rectifiedWage;
}

int numberOfPeople = 1000;
int wageLowerBound = 725;
int wageUpperBound = 4000;

int integerWage = 725;
int hoursPerWeek = 40;
int weeksPerYear = 50;

decimal hourlyWage = 0M;
hourlyWage = rectifyWage(integerWage);

decimal salaryValue = 0M;
salaryValue = yearlySalary(hourlyWage, hoursPerWeek, weeksPerYear);

Console.WriteLine($"integerWage: {integerWage}");
Console.WriteLine($"Rectified Wage: {hourlyWage}");
Console.WriteLine($"Yearly Salary = {salaryValue}");

int[] hourlyWagesArray = new int[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	int generatedWage = 0;

	Random rnd = new Random();
	generatedWage = rnd.Next(wageLowerBound, wageUpperBound);

	hourlyWagesArray[i] = generatedWage;
}

Console.WriteLine("\n");
foreach (int wage in hourlyWagesArray){

	string errorFlag = "";
	if (wage < wageLowerBound || wage > wageUpperBound) {
		errorFlag = "[Wage Out of Bounds]";
	}

	Console.WriteLine($"{wage} {errorFlag}");
}