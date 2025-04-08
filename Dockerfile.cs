FROM maven:3.8.5 - jdk - 11 AS build
     WORKDIR /app
     COPY . .
     RUN mvn clean package

     FROM openjdk:11 - jre - slim
     WORKDIR / app
     COPY--from = build / app / target / my - app.jar.
     ENTRYPOINT["java", "-jar", "my-app.jar"]