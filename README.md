Toy Simulator
	- Based on the commands provided, the Simulator will run and output the resulting position of the toy on board
	- Uses Command Design Pattern to simulate the queueing of the commands
	- Uses Interpreter Design Pattern to read the instructions from a string array and separate them as commands to be executed
	- The Interpreter is designed to convert an input from commandline or file and convert it into commands to execute. 
	- However, it currently does not take input directly either from console or from a file. But can be plugged in seamlessly on top of the Interpreter