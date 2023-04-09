// Tom Chiapete
// Find Roots up to 5000 using C


#include <sys/types.h>  // defines pid_t
#include <unistd.h>		// defines fork
#include <iostream>	// defines cout, cin
#include <stdlib.h>     // defines exit()
#include <math.h>
#include <sys/types.h>	
#include <sys/wait.h>
#include <sys/types.h>
#include <signal.h>


using namespace std;
int i;  // counter used for counting up to 5000

// Declare all of our methods and data members
class Process {
public:
   Process()    {} 
   int findRoot();
private:
};

// Find Root – Process Class
int Process::findRoot()
{
	// Get process ID
      	pid_t  identification = getpid();

      	// Do calulations and print
    	for (; i <5000; i++) 
	{
		cout << "P"<< identification;
		cout << ":" << "";
		cout << "R" << i;
		cout << "=" << "";
            	cout << (double)sqrt(i) << "    "; 
	    	
		if (i%4==0) cout << endl;


		//kill(identification, 9);

		//pid_t chpid;			// the pid of the child which terminated
		//chpid = wait(&identification);	// wait() returns status and chpid


      	}


	exit(0);   // do not return
}

// main() -- executed first, calls fork to create a duplicate child process 
int main()
{
        Process child;

	//pid_t  parentProcess = getpid();

        i = 0;

        fork();     
	child.findRoot();  

}
