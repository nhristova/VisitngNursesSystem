[![Build status](https://ci.appveyor.com/api/projects/status/github/nhristova/VisitngNursesSystem?branch=master&svg=true)](https://ci.appveyor.com/project/nhristova/visitngnursessystem)
[![Coverage status](https://coveralls.io/repos/github/nhristova/VisitngNursesSystem/badge.svg?branch=master)](https://coveralls.io/github/nhristova/VisitngNursesSystem?branch=master)

# Visitng Nurses System

### Individual course project by Nadezhda Hristova

[Web Applications with ASP.NET MVC](https://telerikacademy.com/Courses/Courses/Details/444), Telerik Academy Season 8

Links: 

|  [GitHub](https://github.com/nhristova/VisitngNursesSystem) | 
[Azure](http://visiting-nurses-service.azurewebsites.net/) |

Tasks:

- Test if data models work
- Data models validation
- Update code coverage %

### Project Description

#### Purpose

Data management tool for monitoring and organizing visiting nurses work for families with young children. 

The staff of the visiting nurses social service (`Users`) keep track of the `Families` they work with. Each family has one `Assigned Staff Member`, one or more `Family Members` and one or more `Children`. Staff members conduct `Visits` to `Families` during which they provide advice and assistance to `Family Members` for the care and welbeing of the `Children`.

#### Functionalities
#### Architecture
#### Technologies

----
# Requirements

## Task Description

Design and implement an **ASP.NET MVC application**. It can be a discussion forum, blog system, e-commerce site, online gaming site, social network, or any other web application by your choice.

The application should have:
* **public part** (accessible without authentication)
* **private part** (available for registered users)
* **administrative part** (available for administrators only)

### Administration Part
:no_mouth:
**System administrators** should have administrative access to the system and permissions to administer all major information objects in the system, e.g. to create/edit/delete users and other administrators, to edit/delete offers in a bid system, to edit/delete photos and album in a photo sharing system, to edit/delete posts in a blogging system, edit/delete products and categories in an e-commerce system, etc.


### Mandatory Requirements

- :white_check_mark: :neckbeard: At least 50% code coverage
- :white_check_mark: Continuous integration

### General Requirements

Used technologies, frameworks and development techniques:
* :white_check_mark: **ASP.NET MVC** and **Visual Studio 2015**
* :white_check_mark: **Razor** template engine for generating the UI
	* :white_check_mark: **sections** and **partial views**
	* :white_check_mark: **editor** and/or **display** templates
* :white_check_mark: **MS SQL Server** as database back-end
	* :white_check_mark: **Entity Framework 6** to access the database
	* :white_check_mark: **"repositories" and service layer**
* :no_mouth: Use at least **1 area** (e.g. for administration)
* :no_mouth: :interrobang: Create **tables with data** with **server-side paging and sorting** for every model entity
	* You can use Kendo UI grid, jqGrid, any other library or generate your own HTML tables
* :heart_eyes: **beautiful and responsive UI**
	* :white_check_mark: **Bootstrap**
	* :white_check_mark: Changed the standard theme and applied own web design and visual styles
* :no_mouth: Use the standard **ASP.NET Identity System** for managing users and roles
	* :no_mouth: Your registered users should have at least one of the two roles: **user** and **administrator**
* :white_check_mark:  **AJAX form** communication in some parts of your application 
    - (:no_mouth: :interrobang: SignalR)
* :no_mouth: Use **caching** of data where it makes sense (e.g. starting page)
* :no_mouth: Apply **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side)
* :no_mouth: Prevent yourself from **security** holes (XSS, XSRF, Parameter Tampering, etc.)
	* Handle correctly the **special HTML characters** and tags like `<script>`, `<br />`, etc.
* :white_check_mark: **Unit tests** for the "business" functionality following the best practices for writing unit tests (coverage **min 50%, desirable 80%**)
    * :sunny: Services - 100% 
    * :sunny: :cloud: Controllers - 100% of my code, 21% of manage and account controller
    * :partly_sunny: Data models - 40%
    * :partly_sunny: View models - 44%
* :white_check_mark: :scream: Used **Dependency Inversion** principle and **Dependency Injection** technique following the best practices 
* :white_check_mark: :neckbeard: :ambulance: :sob: :scream: Integrated app with a Continuous Integration server (**Jenkins AND AppVeyor**) - configured unit tests to run on each commit to master branch 
* :no_mouth: **Documentation** of the project and project architecture (as `.md` file, including screenshots)

### Optional Requirements (bonus points) :sleeping:

* :x: Write integration tests and configure them to run as part of your CI build
* :x: Using some king of machine learning (AI)
* :x: Using external devices (e.g. Raspberry Pi)
* :white_check_mark: Hosted the application in Azure

### Good to have (does not give points)
* :white_check_mark: Research and use project management system - GitHub Issues, Trello
* :white_check_mark: Research and use (simple) gitflow (master and development branches)
* :x: Reserach and write user stories and user journey maps

### Deliverables

Put the following in a **ZIP archive** and submit it:
* The **source code** (everything except /bin/, /obj/, /packages/)
* The project documentation
* :no_mouth: Screenshots of your application
* If hosted online - the URL of the application
