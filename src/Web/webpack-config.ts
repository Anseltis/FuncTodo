import * as webpack from 'webpack';
import * as path from 'path';

export default <webpack.Configuration>{
    devtool: 'source-map',
    entry: [
        'webpack-dev-server/client?http://localhost:8080',
        'webpack/hot/only-dev-server',
        path.join(__dirname, 'index.tsx')
    ],
    devServer: {
        publicPath: '/',
        contentBase: './src/Web',
        hot: true,
        historyApiFallback: true,
        inline: true,
        compress: true
    },
    resolve: {
        extensions: ['.ts', '.js', '.tsx']
    },
    output: {
        path: path.join(__dirname, '../../dist/Web'),
        filename: 'index.js',
        publicPath: '/'
    },
    module: {
        rules: [{
            test: /\.ts$/,
            loader: 'tslint-loader?emitErrors=false&failOnHint=false',
            exclude: /node_modules/,
            enforce: 'pre'
        }, {
            test: /\.tsx?$/,
            loader: 'awesome-typescript-loader',
            exclude: /node_modules/
        }]
    },
    plugins: [
        new webpack.HotModuleReplacementPlugin()
    ]
};