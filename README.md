# EverestDVDs
Barebone project for the Application Development Groupwork to create a functional Web application for basic CRUD operation with UAC for different users.


## 1. Getting Started:


> Clone this repo on "Clone or checkout code". [Alt: Download the zip file, unzip and open the solution]
```
https://github.com/ShresthaRajat/EverestDVDs.git
```
> Log into the Github to get collaboration access. 

> Create a separate branch and push the changes on that specific branch only. [Important!]



## 2. Rules:

### Do:
* Create a separate branch by your name for a specific function. ("git checkout -b yourname" or just create a new branch)
* Do your work on the designated files. (ie. work on function2.cs if function 2 is assigned to you)
* Submit a pull request at dev after the function is complete.

## Not to Do:
* Do not touch any other files other than the files related to the task assigned to you.
* Do not push any commits directly on the master branch.
* Do not create unnecessary files.
* Do not make changes to create potential merge conflicts.


## 3. Specifications:

### ER-Diagram:
The following Entity Relationship Diagram contains only the most important bare minimum entities and atributes. If this ER diagram is not valid please open a issue with details on why it is not valid.

![ERD](https://github.com/ShresthaRajat/EverestDVDs/blob/master/EverestDVDs_ERD.svg)


## 4. Work Division:
To divide the load of the groupwork into smaller chunks of simpler tasks.

The following functions as noted from the requirements are similar:
|Functions|Summary|Status|
|:------------:|:-----------------------------------------------:|:-------------:|
| 1, 2, 3, 5 | Simple queries requiring user Input.|Finished|
| 4, 8 | Simple queries to list the contents according to the stored data.|Finished|
| 6, 7 | Issuing and Returning the DVD Copies.|Finished|
| 9 | Adding new DVD (Complex)(also need to add castmembers.)|Not imp(AJAX)|
| 10 | Removing 365 days old DVD Copies.|Incomplete(Pragati)|
|11|Copies on loan order in order of date|Incomplete|
|12|List users who havent loned in past 31 days. (Ignore users who havent Done |Finished|
|13|List all of the dvds which have been loned in the last 31 days. |Finished|
|14|UAC and adding manager| Incomplete|

These tasks will be assigned to each members respectively.

Available Endpoints

```
Function1-5

/CastMembers/FilterByLastName
/CastMembers/FilterFunction2
/DVDProducerActors
/Loans/Loan31Days
/Loans/FilterFunction5
/Loans/FunctionNo8
/Loans/Function12
/Loans/Function13

/Actors
/CastMembers
/DVDDetails
/DVDProducers
/Loans
/MemberCategories
/Members
/producers
```
