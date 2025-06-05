// See https://aka.ms/new-console-template for more information


using Deferly.Core;
using Deferly.Examples;


var deferExample = new DeferExamples();
deferExample.Example();


var asyncDeferExample = new AsyncDeferExamples();
await asyncDeferExample.Example();