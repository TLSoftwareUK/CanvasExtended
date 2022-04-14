// See https://aka.ms/new-console-template for more information
using netDxf;

Console.WriteLine("Hello, World!");

var _loadedDoc = DxfDocument.Load("test_os_small.dxf");
Console.WriteLine("Loaded");

