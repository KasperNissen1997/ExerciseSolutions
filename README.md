# Intrudoctions
This repository is a collection of all the solutions to the exercises handed out in the Programming course, at the [Computer Science education](https://www.ucl.dk/uddannelser/datamatiker) at [UCL](https://www.ucl.dk/) in Odense, Denmark. It is currently a work in progress, with updates happening regularly, following the pace the exercises are handed out at. 

All the solutions in this repository are made by myself, or in close partnership with a groupmember, and are **not guarenteed to be correct**. They may also showcase bad practices, faultily implemented patterns or other abnormalities. This is of course not the intention. These examples are kept in the repository, in the hopes that they may show how my understanding of certain concepts deepen as time goes on.

# Navigating the Solutions
Many of the exercises were intended to be solved within their own standalone C# solution. This means that when merging them all into one one-stop VS Studio solution, the solution has been structured in a categorized manner, to help find the solution to any specific exercise. 

All exercises fromt the first term are located in the folder aptly named "First Term". Exercises from the second term are located in the folder "Second term" etc.

## First Term Solutions
All exercises that do not require their own files, are solved within the [Program](FirstTerm/ExerciseProject/Program.cs) class in the ExerciseProject, with the ability to toggle which exercise's solution should be executed being at the top of the file.

Exercises that require their own files, are solved within their own unique folder. Folders are named intuitively, to indicate which exercise's solution they hold, with examples such as the folder [Exercise7](FirstTerm/ExerciseProject/Exercise7), which contains the solution to exercise 7. *Note that in the solutions for the first term exercises with multiple steps that build upon each other, only the result of the final step is saved and presented in this repository.* This unfortunately makes it difficult in some cases to see how the exercise had been solved, as well as which steps had been taken. This approach is changed in all terms going forward, and all exercises will have their own dedicated solution project, instead of some exercise solutions being overwritten.

Each exercise that requires unit-tests to be run also has a corresponding MS Test Project, aptly named to indicate which exercise it relates to. These names are derived from the exercise sheets provided during the course. An example of this is the [DisaheimTestProject](FirstTerm/TestProjects/DisaheimTestProject), which holds all the tests related to the exercises that center around the course-provided Disaheim case.

## Second Term Solutions
As the second term is just getting started, the structure is not yet determined. Untill any changes are mentioned here, the categorization of the second term solutions follow that of the first term solutions.
