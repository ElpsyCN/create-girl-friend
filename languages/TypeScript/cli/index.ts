import { createCommand } from "commander";
import pkg from "../package.json";

const program = createCommand();
program.version(pkg.version);
