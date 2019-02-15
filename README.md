# Introduction

Simple web api to reveal details about the .NET Core host in which it is running.

To invoke with PowerShell, do something like:

    # return current version and date/time
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/version
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/datetime

    # return information about the server's runtime environment
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/environment
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/hostingenvironment
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/assemblyinfo

    # execute a request that delays and returns a result of a specified size
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/load
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/load?blobsize=55"&"requestid=1234"&"delay=2000

    # attempt to open a socket at google.com port 80
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/tcpconn/google.com/80

    # attempt to open a socket at 172.217.9.14 port 80
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/tcpconn/172.217.9.14/80

    # attempt to ping localhost
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/ping/localhost

    # attempt to ping 127.0.0.1
    Invoke-RestMethod http://corehostinfo.azurewebsites.net/api/ping/127.0.0.1

Note that if the returned object has keys that only differ by case, like
you might see if hosted on a Linux box, then the PowerShell parser won't deal
with that well and the output won't be formatted into a nice table.