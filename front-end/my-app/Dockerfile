FROM node

WORKDIR /app

COPY front-end/my-app ./

RUN npm install

RUN npm run build

COPY . .

CMD ["npx", "serve -s build "]
