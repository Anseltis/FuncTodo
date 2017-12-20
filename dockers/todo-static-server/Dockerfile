FROM node AS build-env

COPY ./src/Web /home/web/src/Web
COPY *.json /home/web/

WORKDIR /home/web

RUN npm install
RUN npm run build

# build runtime image

FROM nginx
COPY --from=build-env /home/web/dist/Web /usr/share/nginx/html


