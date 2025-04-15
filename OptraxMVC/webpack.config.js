const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
/*const { BundleAnalyzerPlugin } = require('webpack-bundle-analyzer');*/
const fs = require('fs');
const isDev = process.env.NODE_ENV !== 'production';

module.exports = {
    mode: isDev ? 'development' : 'production',
    entry: {
        main: './wwwroot/js/site.js',
        location: ['./wwwroot/js/location/location.js', './wwwroot/js/map/map.js'],
        plant: './wwwroot/js/plants/plants.js',
        tabs: './wwwroot/js/tabs.js',
        site: './wwwroot/scss/site.scss'
    },
    output: {
        filename: '[name].bundle.js', // creates main.bundle.js and styles.bundle.js
        path: path.resolve(__dirname, 'wwwroot/dist'),
    },
    devtool: isDev ? 'source-map' : false,
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: { presets: ['@babel/preset-env'] }
                }
            },
            {
                test: /\.scss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'sass-loader'
                ],
            },
            {
                test: /\.css$/i,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader'
                ],
            },
            {
                test: /\.(woff2?|eot|ttf|otf|png|jpg|jpeg|gif|svg)$/i,
                type: 'asset/resource'
            }
        ]
    },
    //resolve: {
    //    alias: {
    //        'leaflet-path-drag': path.resolve(__dirname, 'node_modules/leaflet-path-drag/src/Path.Drag.js')
    //    }
    //},
    plugins: [
        //new BundleAnalyzerPlugin(),
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: '../css/[name].css',
        }),
        {
            apply: (compiler) => {
                compiler.hooks.afterEmit.tap('AfterEmitPlugin', (compilation) => {
                    console.log('Webpack wrote files to:', compilation.outputOptions.path);
                    fs.readdir(compilation.outputOptions.path, (err, files) => {
                        if (err) console.error('Error reading dist folder:', err);
                        else console.log('Contents:', files);
                    });
                });
            }
        }
    ],
    optimization: {
        minimize: !isDev,
        splitChunks: {
            chunks: 'all',
            minSize: 0,
            cacheGroups: {
                shared: {
                    test: /[\\/]node_modules[\\/]/,
                    name: 'shared',
                    chunks: 'all',
                    enforce: true,
                    priority: 20,
                },
                vendorUI: {
                    test: /[\\/]node_modules[\\/](popperjs|jquery-ui)[\\/]/,
                    name: 'vendor-ui',
                    chunks: 'all',
                    priority: 15,
                    enforce: true,
                },
                default: false,  
                vendors: false  
            }
        }
    },
    //mode: isDev ? 'development' : 'production',
};
