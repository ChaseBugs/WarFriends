// ESLint flat config for TypeScript code (backend tooling and Admin UI).
// The rules mirror Docs/CODE_STYLE.md; layout is left to Prettier.
// Dev dependencies: eslint, typescript-eslint, eslint-plugin-import, eslint-config-prettier.

import prettierConfig from "eslint-config-prettier";
import importPlugin from "eslint-plugin-import";
import tseslint from "typescript-eslint";

const MAX_FUNCTION_LINES = 40;
const MAX_FILE_LINES = 300;
const MAX_PARAMETERS = 3;

export default tseslint.config(
  {
    ignores: [
      "Clients/**",
      "Server/content/**",
      "Server/artifacts/**",
      "**/node_modules/**",
      "**/dist/**",
      "**/build/**",
      "**/.next/**",
      "**/coverage/**",
    ],
  },
  {
    files: ["**/*.{ts,tsx}"],
    extends: [...tseslint.configs.strict],
    plugins: { import: importPlugin },
    settings: { "import/internal-regex": "^@/" },
    rules: {
      "@typescript-eslint/no-explicit-any": "error",
      "@typescript-eslint/no-non-null-assertion": "warn",
      "@typescript-eslint/no-unused-vars": "error",
      "@typescript-eslint/consistent-type-imports": ["error", { prefer: "type-imports" }],
      "@typescript-eslint/consistent-type-definitions": ["error", "interface"],
      "@typescript-eslint/explicit-module-boundary-types": "error",
      "@typescript-eslint/no-magic-numbers": [
        "warn",
        {
          ignore: [-1, 0, 1],
          ignoreArrayIndexes: true,
          ignoreDefaultValues: true,
          ignoreEnums: true,
          ignoreNumericLiteralTypes: true,
          ignoreReadonlyClassProperties: true,
          ignoreTypeIndexes: true,
        },
      ],
      "@typescript-eslint/naming-convention": [
        "error",
        { selector: "typeLike", format: ["PascalCase"] },
        { selector: "interface", format: ["PascalCase"], custom: { regex: "^I[A-Z]", match: false } },
      ],
      "no-nested-ternary": "error",
      "no-empty": "error",
      "max-params": ["error", MAX_PARAMETERS],
      "max-lines-per-function": ["warn", { max: MAX_FUNCTION_LINES, skipBlankLines: true, skipComments: true }],
      "max-lines": ["warn", { max: MAX_FILE_LINES, skipBlankLines: true, skipComments: true }],
      "import/no-default-export": "error",
      "import/order": [
        "error",
        {
          groups: ["builtin", "external", "internal", ["parent", "sibling", "index"]],
          "newlines-between": "always",
          alphabetize: { order: "asc", caseInsensitive: true },
        },
      ],
    },
  },
  {
    // Next.js requires default exports from its route convention files.
    files: ["**/app/**/{page,layout,loading,error,not-found,template,default}.tsx"],
    rules: { "import/no-default-export": "off" },
  },
  prettierConfig,
  {
    // eslint-config-prettier turns curly off; "all" does not conflict with Prettier, so restore it last.
    files: ["**/*.{ts,tsx}"],
    rules: { curly: ["error", "all"] },
  },
);
