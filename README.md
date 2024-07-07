**Backend Case Study**

To run the project, use the following command: docker compose up


**CoensioApi** Endpoints:


Auth:
To get admin role ulvidemirsoy@gmail.com to login, any other logins will provide user role.


Questions:
Crud Endpoints for 3 different type of questions(admin role).


Test:
To generate test with name and random selected questions use Generate endpoint(admin role).


Assignment:
After generating test assign it to a user using email adress(admin role) using post assignment endpoint.
Then login with assigned user email and see assigned tests with get assignment endpoint.
Then using Assignment/Submission endpoint, fill answers and send submission, this will trigger EvaluatorAPI.



**CoensioEvaluatorApi** Endpoints:


You can see submitted test results with list endpoint.

