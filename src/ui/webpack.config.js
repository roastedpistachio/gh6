var path    = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var autoprefixer = require('autoprefixer');

module.exports = {
  devtool: 'sourcemap',
  entry: {},
  module: {
    loaders: [
       { test: /\.js$/, exclude: [/app\/lib/, /node_modules/], loader: 'ng-annotate!babel' },
       { test: /\.html$/, loader: 'raw' },
       { test: /\.scss$/, loader: 'style!css!postcss!sass' },
       { test: /\.css$/, loader: 'style!css!postcss' },
       { test: /\.(eot|woff|woff2|ttf)$/, loader: 'url'},
       { test: /\.json$/, loader: 'json'}
    ]
  },
  postcss: () => {
    return [autoprefixer];
  },
  sassLoader: {
    includePaths: [
      path.resolve(__dirname, 'node_modules/bootstrap-sass/assets/stylesheets'),
      path.resolve(__dirname, 'client/app')
    ]
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: 'client/index.html',
      inject: 'body',
      hash: true
    }),
    new webpack.optimize.CommonsChunkPlugin({
      name: 'vendor',
      minChunks: function (module, count) {
        return module.resource && module.resource.indexOf(path.resolve(__dirname, 'client')) === -1;
      }
    })
  ]
};
