# .NET Sales Data Analysis Assessment

## Overview

This project is a .NET Core console application developed for analyzing ice cream parlor sales data. The application reads raw CSV sales data, validates records, and generates multiple analytical reports using basic data structures such as lists and dictionaries.

The solution was implemented without using LINQ, SQL/NoSQL databases, or external data-processing libraries, following the assignment constraints.

---

## Features

### Data Validation
The program validates records and detects:
- Invalid total price calculations
- Quantity less than 1
- Negative unit prices
- Negative total prices
- Malformed dates

Invalid records are separated from valid records and displayed with error messages.

---

## Reports Generated

### 1. Total Sales of the Store
Calculates the total revenue generated from all valid records.

### 2. Month-wise Sales Totals
Generates monthly revenue summaries.

### 3. Most Popular Item Each Month
Identifies the item with the highest quantity sold each month and calculates:
- Minimum order quantity
- Maximum order quantity
- Average order quantity

### 4. Highest Revenue Item Each Month
Finds the item generating the highest revenue in each month.

### 5. Month-to-Month Growth Per Item
Calculates revenue growth percentage for each item between consecutive months.

---

## Technologies Used

- C#
- .NET Core Console Application
- Lists
- Dictionaries

---

## Assignment Constraints Followed

- No LINQ used
- No SQL/NoSQL database used
- No external libraries used for data processing
- Implemented using basic data structures and loops

---

## Project Structure

The implementation focuses on clear sequential processing for easier understanding of the validation and reporting stages.

---

## How to Run

1. Open the solution in Visual Studio
2. Build the project
3. Run the application
4. The reports will be displayed in the console window

---

## Output

The console output includes:
- Validation summary
- Invalid record details
- Sales reports
- Revenue analysis
- Growth analysis

---

## Author

Mohammed Ammaar Hussain
