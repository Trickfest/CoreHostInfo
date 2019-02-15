# Introduction

Simple web api to reveal details about the .NET Core host in which it is running.

To invoke with PowerShell, do something like:

    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/version
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/datetime
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/environment
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/hostingenvironment
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/load
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/load?blobsize=55"&"requestid=1234"&"delay=2000
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/assemblyinfo
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/tcpconn/google.com/80
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/ping/localhost

Note that if the returned object has keys that only differ by case, like
you might see if hosted on a Linux box, then the PowerShell parser won't deal
with that well and the output won't be formatted into a nice table.