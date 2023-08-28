# Introductions
This repository is a collection of all the solutions to the exercises handed out in the Programming course, at the [Computer Science education](https://www.ucl.dk/uddannelser/datamatiker) at [UCL](https://www.ucl.dk/) in Odense, Denmark. It is currently a work in progress, with updates happening regularly, following the pace the exercises are handed out at. 

All the solutions in this repository are made by myself, or in close partnership with other students, and are **not guarenteed to be correct**. They may also showcase bad practices, faultily implemented patterns or other abnormalities. This is of course not the intention. These examples are kept in the repository, in the hopes that they may show how my understanding of certain concepts deepen as time goes on.

# Navigating the Solutions
Many of the exercises were intended to be solved within their own standalone VS solution. This means that when merging all standalone exercise solutions into one monolith VS solution, the file and project structure has been designed in a categorized manner, in order to help find the solution to any specific exercise from the course.

All exercises from the first term are located in the folder aptly named [First Term](FirstTerm). Exercises from the second term are located in the folder [Second term](SecondTerm) etc.

## 1st Term Solutions
All exercises that do not require their own files, are solved within the [Program](FirstTerm/ExerciseProject/Program.cs) class in the ExerciseProject, with the ability to toggle which exercise's solution should be executed, located at the top of the file.

Exercises that require their own files, are solved within their own unique folder. Folders are named intuitively, to indicate which exercise's solution they hold, with examples such as the folder [Exercise7](FirstTerm/ExerciseProject/Exercise7), which contains the solution to exercise 7. *Note that in the solutions for the first term exercises with multiple steps that build upon each other, only the result of the final step is saved and presented in this repository.* This unfortunately makes it difficult in some cases to see how the exercise had been solved, as well as which steps had been taken. This approach is changed in all terms going forward, and all exercises will have their own dedicated solution project, instead of some exercise solutions being overwritten.

Each exercise that requires unit-tests to be run also has a corresponding MS Test Project, aptly named to indicate which exercise it relates to. These names are derived from the exercise sheets provided during the course. An example of this is the [DisaheimTestProject](FirstTerm/TestProjects/DisaheimTestProject), which holds all the tests related to the exercises that center around the course-provided Disaheim case.

## 2nd Term Solutions
Each exercise has its own physical folder, (as well as a corresponding solution folder to maintain consistency in the structure of the directory) where the project, holding the solution for the corresponding exercise, can be found. *Note that some of the tests written for the exercises solved in this term require access to the VPN of UCL, in order for them to resolve succesfully.*

## 3rd Term Solutions
The structure of the 2nd term solutions is continued here. The naming convention of the exercises has changed, and as a result of this, the names of the folders containing the solutions from this term has also changed, in order to maintain consistency. *Note that since not all solutions require a project file to be solved, the folders containing the solutions might not be immediately visible from the solution explorer.*