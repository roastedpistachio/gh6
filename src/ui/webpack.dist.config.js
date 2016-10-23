var webpack = require('webpack');
var path    = require('path');
var config  = require('./webpack.config');

config.output = {
  filename: '[name].bundle.js',
  publicPath: '',
  path: path.resolve(__dirname, 'dist')
};

config.module.loaders = config.module.loaders.map(loader => {
  if (loader.test ===  /\.scss$/) {
    return { test: /\.scss$/, loader: ExtractTextPlugin.extract('style-loader', 'css!postcss!sass', { publicPath: '' }) }
  } else if (loader.test ===  /\.css$/) {
    return { test: /\.css$/, loader: ExtractTextPlugin.extract('style-loader', 'css!postcss', { publicPath: '' }) }
  }
  return loader;
});

config.plugins = config.plugins.concat([
  new ExtractTextPlugin('styles/[name].css', {
    allChunks: true
  }),
  new webpack.optimize.UglifyJsPlugin({
    mangle: {
      except: ['$super', '$', 'exports', 'require', 'angular']
    }
  })
]);

module.exports = config;
