IF NOT EXIST bin mkdir bin
%SystemRoot%\Microsoft.NET\Framework\v1.0.3705\csc /t:library /out:bin\Forum.dll /r:System.dll /r:System.Web.dll /r:System.Xml.dll /r:System.Data.dll /recurse:*.cs