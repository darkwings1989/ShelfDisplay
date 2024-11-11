Documentation:

A. Instructions for running the project:
   There are two options.
   1. Use this link to the demo that I created to run the project:
      https://darkwings1989-github-io-shelf-dispaly-demo.vercel.app/
   2. Make a build by yourself from Unity.
      a. Open your project in Unity.
      b. Go to File > Build Settings.
      c. Select WebGL as the target platform and click Switch Platform.
      d. Click Build and choose a folder for the WebGL build output (e.g., Build or WebGLBuild).
      e. Unity will generate an HTML file, a Build folder with .js/.wasm files, and a TemplateData folder.

      Then the HTML file, a build folder with .js/.wasm files, and a TemplateData folder need to be uploaded to a server (it can be local, I used vercel.app with the instruction they provided (and it works with a GitHub account).

B. Overview of my code structure and design decisions:
   I am using a Singleton pattern for the server communication between the client and the server.
   For the client, I chose to use the MVC pattern.
   I'm using one controller that acts as a mediator between the client's view and the data that comes from the server. This way, the model (the data), controller, and view are separated and easy to maintain and expand when needed.
   I designed the code so that it will be easy to modify and add new logic to the App.
