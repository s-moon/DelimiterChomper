# Delimiter Chomper
A small utility to maintain a certain number of delimiters in a text file, and no more.

#### Usage
**DelimiterChomper Delimiter Direction Allowed FilenameIn FilenameOut**

* Delimiter: E.g. \",\" or \"|\"");
* Direction: E.g. Left or Right");
* Allowed: Number of delimiters to allow before removing remainder");
* FilenameIn: Path to the file to process");
* FilenameOut: Path of file to write output to");
            
E.g.

DelimiterChomper "," Left 5 C:\\foo.csv C:\\foo-out.csv

This will remove all commas after the fifth one found, starting from the left, in file foo.csv

