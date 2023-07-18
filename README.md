# Terminal-API
# Start
There are differnt ways to start this API:

- In your IDE: Check out the Repo and run it in your ID
- Docker: Pull the Docker Image https://hub.docker.com/r/flowhc/terminal-api
- With UI: Use the Docker-Compose file https://github.com/flowhc/Terminal-Infrastructur

# Usage
After Starting the App, you can use the UI (https://github.com/flowhc/Terminal-UI) to play around. There is also a Postman Collection in the Repo.
If you want to consume it. You find the Endpoints under the following link http://localhost:8080/Ship/

- Read: (GET) http://localhost:8080/Ship/Read/{ShipID}
- ReadAll: (GET) http://localhost:8080/Ship/ReadAll
- Create: (POST) http://localhost:8080/Ship/Create Body: {"name":"Ship1","length":200.0,"width":21.0,"code":"CABC-1234-A1"}
- Update: (PUT) http://localhost:8080/Ship/Update Body: {"name":"Ship1","length":200.0,"width":21.0,"code":"CABC-1234-A1"}
- Delete: (DELETE) http://localhost:8080/Ship/Delete/{ShipID}
