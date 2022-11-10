# ExerciseSolutions
This repository is a collection of all the solutions to the exercises handed out in the Programming course, at the [Computer Science education](https://www.ucl.dk/uddannelser/datamatiker) at [UCL](https://www.ucl.dk/) in Odense, Denmark. It is currently a work in progress, with updates happening regularly, following the pace the exercises are handed out at.

All solutions are developed by myself, Kasper Nissen.

# Navigating the Code
Many of the exercises were intended to be solved within their own standalone C# solution. This means that when merging them all into one big solution, the code has been structured in a way that makes it easily deductable which code belongs to what exercise. 

All exercises that do not require their own files, are solved within the [Program](ExerciseProject/Program.cs) class, with the added ability to toggle which exercise's solution should be executed.

Exercises that require their own files, are solved within their own unique folder. Folders are named intuitively, to indicate which exercise's solution they hold, with examples such as the folder [Exercise7](ExerciseProject/Exercise7), which contains the solution to exercise 7.

Each exercise that requires unit-tests to be run also has a corresponding MS Test Project, aptly named to indicate which exercise it relates to. These names are derived from the exercise sheets provided during the course. An example of this is the [DisaheimTestProject](DisaheimTestProject), which holds all the tests related to the exercises that center around the course-provided Disaheim case.
