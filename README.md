Documentation:

A. Instructions for running the project:
   There are two options.
   1. Use this link to the demo that I created to run the project:
      https://darkwings1989-github-io-shelf-dispaly-demo.vercel.app/
   2. Make a build by yourself from Unity.
      * Open this project in Unity.
      * Go to File > Build Settings.
      * Select WebGL as the target platform and click Switch Platform.
      * Before making the build, go to PlayerSettings (you can access it from the build settings window) in it choose "Settings for WebGL"
      * in the "Publishing Settings" choose in the "Competition Format" field one of those two formats: Gzip or Brotli; "Maximum Memory Size" to 512mb (for this project it is enough);  "Initial Memory Size" can be between 64 and 256 (for this project I chose 256.
      * Click Build and choose a folder for the WebGL build output (e.g., Build or WebGLBuild).
      * Unity will generate an HTML file, a Build folder with .js/.wasm files, and a TemplateData folder.

      Then the HTML file, a build folder with .js/.wasm files, and a TemplateData folder need to be uploaded to a server (it can be local, I used vercel.app with the instruction they provided (and it works with a GitHub account).

B. Overview of my code structure and design decisions:
   For the client, I chose to use the MVC pattern.
   I'm using one controller that acts as a mediator between the client's view and the data that comes from the server. This way, the model (the data), controller, and view are separated and easy to maintain and expand when needed.
   I designed the code so that it will be easy to modify and add new logic to the App.

C. Decisions:
   * I did a static 3D shelf because I know that at the same time, the shelf will have a max of 3 products.
   * The edit of the product name and the price are not very user-friendly on mobile but with consideration of the time I had for the assignment, I decided to focus on a clean code and good design.
   * I created a placeholder for a product 3d model if in the future there will be a model for every product, right now the name and description that I am getting from the server are generic so I decided that it will be a "future" task when
   * it will be relevant to make this feature.
