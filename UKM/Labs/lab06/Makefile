.PHONY : clean

executable=lab03

all: install

install: lab03
	-mkdir bin
	cp lab03 bin

lab03: *.o
	${CXX} $^ -o $@

.cpp.o:
	${CXX} $^ -c

clean:
	-rm *.o
	-rm ${executable}
	-rm -rf bin