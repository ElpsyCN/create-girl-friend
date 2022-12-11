import { createCommand } from "commander";
import pkg from "../package.json";

import inquirer from "inquirer";

const program = createCommand();
program.version(pkg.version);

interface input {
  type: string;
  name: string;
  message: string;
}
const questions: input[] = [
  {
    type: "input",
    name: "name",
    message: "你的名字？",
  },
];

export async function ask() {
  const answers = await inquirer.prompt(questions);
  return answers;
}
