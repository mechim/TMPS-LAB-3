all: compile run
	
compile: 
	mcs $(wildcard *.cs) 

run: 
	mono main.exe

clean:
	-rm $(wildcard *.exe)

