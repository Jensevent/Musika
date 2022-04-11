FROM node:lts-alpine

WORKDIR /app

COPY front-end/my-app ./

RUN npm install

COPY front-end/my-app .

RUN npm run build --production

RUN npm install -g serve

EXPOSE 3000

#CMD serve -s build

CMD npm run build
#CMD ["npm", "start"]

#CMD ["npx", "serve", "-s", "build"]
#MD ["serve", "-s", "build"]