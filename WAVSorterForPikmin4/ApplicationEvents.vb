Imports System.Reflection
Imports System.IO

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        ' Combine all assemblies into one .EXE
        Private WithEvents CurrentDomain As AppDomain = AppDomain.CurrentDomain
        Private Function CurrentDomain_AssemblyResolve(sender As Object, args As ResolveEventArgs) Handles CurrentDomain.AssemblyResolve
            Dim thisAssembly As Assembly = Assembly.GetExecutingAssembly()
            Dim name = args.Name.Substring(0, args.Name.IndexOf(","c)) & ".dll"
            Dim resources = thisAssembly.GetManifestResourceNames().Where(Function(s) s.EndsWith(name))

            If resources.Count() > 0 Then
                Dim resourceName = resources.First()

                Using stream As Stream = thisAssembly.GetManifestResourceStream(resourceName)
                    If stream Is Nothing Then Return Nothing
                    Dim block = New Byte(stream.Length - 1) {}
                    stream.Read(block, 0, block.Length)
                    Return Assembly.Load(block)
                End Using
            End If

            Return Nothing

        End Function
    End Class
End Namespace
