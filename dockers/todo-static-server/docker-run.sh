docker stop todo-static-server
docker run -it --rm -p 8080:80 -d --name todo-static-server todo-static-server