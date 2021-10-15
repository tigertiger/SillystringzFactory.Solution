# Dr. Sillystringz & the Great Broken Factory

#### Let's not have any Staplerfahrer Klaus incidents this month, boys

#### Melissa Schatz-Miller

<p align="center">
  <img src="SCHEMA IMG">  
</p>

## Technologies Used

* _C#_
* _.NET 5_
* _NuGet_
* _ASP.NET Core_
* _Entity Framework_

## Description

_Describ_


## Instructions

### Technology Requirements

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* A text editor like [VS Code](https://code.visualstudio.com/)

### Setup/Installation


* Clone [this repository](https://github.com/tigertiger/SillystringzFactory.Solution) to an empty folder or to your desktop, or download and open the Zip on your local machine. Instructions for cloning can be found [here](https://docs.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository-from-github/cloning-a-repository).
* Open the Factory folder in your preferred text editor. We'll come back to this shortly.

* Set up your SQL database:
  - Create a new ```appsettings.json``` file in your Factory/Factory folder
  - Copy the following code into that file, replacing YOUR_PASSWORD with your MySql password:
```
    {
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Port=3306;database=melissa_schatzmiller;uid=root;pwd=YOUR_PASSWORD;"
      }
    }
```
* Set up your SQL database, continued:
  - Open a new terminal and run ```mysql -uroot -p<YOUR_PASSWORD>```
  - Open MySQL Workbench
  - Go to Navigator > Administration and select Data Import/Restore
  - In Import Options, select Import from Self-Contained File
  - Navigate to melissa_schatzmiller.sql
  - Under Default Schema to be Imported To, select New and enter melissa_schatzmiller as the name of the database. Click Ok!
  - Navigate to the Import Progress tab and click Start Import at the bottom right of the window
  - After finishing the steps above, reopen Navigator > Schemas. Right click and select Refresh All. The melissa_schatzmiller database should appear.  

* Return to Factory in your text editor
* Restore and build the project:
  - Navigate to the Factory/Factory folder in the command line or terminal  
    -- Run ```dotnet restore``` to restore the project dependencies  
    -- Run ```dotnet build``` to build and compile the project  

* Use the Web App:
  - Navigate to the Factory/Factory folder in the terminal
  - Run ```dotnet run``` 
  - If you would like to be able to continue viewing the site while making changes to its content, instead run ```dotnet watch run```
  - Access http://localhost:5000/ in your browser to view & interact with the web app

## Known Bugs

* _No known bugs at this time_

## License

_[GPL](https://opensource.org/licenses/gpl-license)_
_Copyright (c) 2021, Melissa Schatz-Miller_

## Contact Information  

Melissa Schatz-Miller <melissa.scmi@gmail.com>  
_Please feel free to reach out to me with suggested changes/improvements, or if you have any questions._