// TODO:
// - react production https://facebook.github.io/react/docs/optimizing-performance.html#use-the-production-build
// - debug
// - use hash in all files

const path = require('path');
const HTMLWebpackPlugin = require('html-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const webpack = require('webpack');
const autoprefixer = require('autoprefixer');
// const FaviconsWebpackPlugin = require('favicons-webpack-plugin');

const isProd = process.env.NODE_ENV === 'production';

console.log(`NODE_ENV: '${process.env.NODE_ENV}'`); // eslint-disable-line no-console
console.log(`Production: ${isProd}`); // eslint-disable-line no-console

module.exports = {
    entry: './src/index.jsx',
    output: {
        path: path.join(__dirname, 'dist'),
        filename: 'stockpot.js'
    },
    devtool: isProd ? false : 'source-map',
    resolve: {
        extensions: ['.js', '.json', '.jsx']
    },
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: ExtractTextPlugin.extract({
                    fallback: { loader: 'style-loader', options: { sourceMap: true } },
                    use: [
                        { loader: 'css-loader', options: { sourceMap: true } },
                        { loader: 'postcss-loader', options: { sourceMap: true, plugins: [autoprefixer] } },
                        { loader: 'sass-loader', options: { sourceMap: true } }
                    ]
                })
            },
            {
                test: /\.js?x$/,
                exclude: /node_modules/,
                use: { loader: 'babel-loader', options: { presets: ['es2015', 'react'] } }
            },
            {
                test: /\.(jpe?g|png|gif|svg)$/,
                use: 'file-loader?name=images/[name].[ext]'
            },
            {
                test: /\.(eot|woff2?|ttf)$/,
                use: 'file-loader?name=fonts/[name].[ext]'
            }
        ]
    },
    devServer: {
        contentBase: path.join(__dirname, 'dist'),
        compress: true,
        // port: 9000,
        stats: 'errors-only',
        overlay: {
            warnings: true,
            errors: true
        },
        // open: true,
        hot: true
    },
    plugins: [
        new HTMLWebpackPlugin({
            template: './src/index.html',
            hash: true
        }),
        new ExtractTextPlugin({
            disable: !isProd,
            filename: 'stockpot.css'
        }),
        /*
        new FaviconsWebpackPlugin({
            logo: './src/images/remote.png',
            prefix: 'images/icons-[hash:6]/',
            background: '#fff',
            title: 'Stockpot'
        }),
        */
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NamedModulesPlugin()
    ]
};
