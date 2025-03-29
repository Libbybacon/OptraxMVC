const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const fs = require('fs');
const isDev = process.env.NODE_ENV !== 'production';

module.exports = {
    entry: {
        main: './wwwroot/js/site.js',
        mapPage: ['./wwwroot/js/location/location.js', './wwwroot/js/map/map.js'],
        //map: './wwwroot/js/map/map.js',
        tabs: './wwwroot/js/tabs.js',
/*        styles: './wwwroot/scss/site.scss'*/
    },
    output: {
        filename: '[name].bundle.js', // creates main.bundle.js and styles.bundle.js
        path: path.resolve(__dirname, 'wwwroot/assets/js'),
    },
    devtool: isDev ? 'source-map' : false,
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env']
                    }
                }
            },
            {
                test: /\.scss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'sass-loader'
                ],
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: '../css/site.css',
        }),
        {
            apply: (compiler) => {
                compiler.hooks.afterEmit.tap('AfterEmitPlugin', (compilation) => {
                    console.log('✅ Webpack wrote files to:', compilation.outputOptions.path);
                    fs.readdir(compilation.outputOptions.path, (err, files) => {
                        if (err) console.error('❌ Error reading dist folder:', err);
                        else console.log('📦 Contents:', files);
                    });
                });
            }
        }
    ],
    mode: isDev ? 'development' : 'production',
};
