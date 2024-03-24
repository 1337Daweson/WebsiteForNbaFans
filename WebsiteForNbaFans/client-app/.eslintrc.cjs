module.exports = {
    env: {
      node: true,
    },
    extends: [
        'eslint:recommended',
        'plugin:vue/vue3-recommended',
      ],
      parserOptions: {
        ecmaVersion: 'latest',
      },
      ignorePatterns: ['src/presets/**/*'],
    rules: {
      'vue/require-default-prop': 'off',
      'quotes': [2, 'single', { 'avoidEscape': true, 'allowTemplateLiterals': true }],
      'semi': 'warn',
      'vue/multi-word-component-names': ['error', {
        'ignores': ['Navbar'],
      }],
      'comma-dangle': ['warn', 'always-multiline'],
      'vue/no-template-shadow': 'off',
    },
  };