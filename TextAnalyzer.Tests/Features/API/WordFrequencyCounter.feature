Feature: WordFrequencyCounter
	As an author
	I want to know the number of times each word appears in a sentence
	So that I can make sure I'm not repeating myself

# Legends (Annotations)
# PAT - ProductAcceptanceTest
# NAT - NegativeAcceptanceTest
# TAT - TechnicalAcceptanceTest

@PAT
Scenario: Calculate Word Count
	Given I entered 'This is a statement, and so is this.' into the program
	When the calculation called
	Then the total no of word should return a distinct list of words in the sentence and the number of times they have occurred

@PAT
Scenario: Add a sentence to a concurrent queue
	Given I entered 'This is a statement, and so is this.' into the program
	When get top record of concurrent queue
	Then The sentence 'This is a statement, and so is this.' should exist 
	And the same as given the sentence 'This is a statement, and so is this.'

@PAT
Scenario: Reset Word Frequency Count List
	Given I entered 'This is a statement, and so is this.' into the program
	When the calculation and Reset are called
	Then the total no of word should return '0'

@PAT
Scenario: Case sensitive 
	Given I entered 'this THIS tHIS This' into the program
	When the calculation called
	Then the total no of word should return '1'
	And the word's count should return '4'

@NAT
Scenario: Invalid blank character
	Given I entered '          ' into the program
	When the calculation called
	Then the total no of word should return '0'

@NAT
Scenario: Extra spaces between two words
	Given I entered 'aa         aa' into the program
	When the calculation called
	Then the total no of word should return '1'

@NAT
Scenario: Extra spaces before and after a word
	Given I entered '         this       ' into the program
	When the calculation called
	Then the total no of word should return '1'

@NAT
Scenario: Extra spaces after a word
	Given I entered 'this       ' into the program
	When the calculation called
	Then the total no of word should return '1'