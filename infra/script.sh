#!/bin/zsh

curl -X POST -H "Content-Type: application/json" \
    --data @sql-server-config-cdc.json \
    http://localhost:8083/connectors
    
    
