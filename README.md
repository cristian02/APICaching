# API Caching with Redis 

This example was create using .Net Core 6. 
Note: We're using a docker container to run redis. 

<p>Commands executed</p>
<ol>
  <li>dotnet --version </li> Check out your dotnet version 
  <li>dotnet new webapi -n "APIname" </li> Create a project type webapi, don't forget replace APIname
  <li>dotnet build </li> To build your project 
  <li>docker run --name my-redis -p 49153:6379 -d redis</li> Create redis instance at docker 
  <li>dotnet add package Microsoft.EntityFrameworkCore</li> Include Entity Framework Core
  <li>dotnet add package Microsoft.EntityFrameworkCore.SqlServer</li> Include Microsoft.EntityFrameworkCore.SqlServer 
  <li>dotnet add package Microsoft.EntityFrameworkCore.Design</li> Include Microsoft.EntityFrameworkCore.Desing
  <li>dotnet add package Microsoft.EntityFrameworkCore.Tools</li>Include Microsoft.EntityFrameworkCore.Tools
  <li>dotnet add package StackExchange.Redis</li> Include StackExchange.Redis
  <li>dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis</li> Include Microsoft.Extensions.Caching.StackExchangeRedis
  <li>dotnet ef migrations add (description)</li>
  <li>dotnet ef database update</li>
</ol>

Look out this command
dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models


<!-- CONTACT -->
## Contact
Cristian Martínez Hernández 

[![LinkedIn][linkedin-shield]][linkedin-url]


<!-- MARKDOWN LINKS & IMAGES -->
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/cristian-mart%C3%ADnez-hern%C3%A1ndez-08043699/
