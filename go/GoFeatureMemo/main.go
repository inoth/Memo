package main

import (
	"time"
)

var input string

func main() {
	// i := 1
	// defer func() {
	// 	println(i)
	// 	println("iiiiii")
	// }()
	// i++
	// println(i)
	// println("aaaaaaa")
	// println("bbbbbbb")
	ch := make(chan int, 5)
	i := 0
	go func() {
		defer close(ch)
		i++
		ch <- i
		time.Sleep(time.Duration(5) * time.Second)
		i++
		ch <- i
		time.Sleep(time.Duration(5) * time.Second)
		i++
		ch <- i
		time.Sleep(time.Duration(5) * time.Second)
		i++
		ch <- i
		time.Sleep(time.Duration(5) * time.Second)
		i++
		ch <- i
	}()
	println("等待中。。。")
	for {
		if val, ok := <-ch; ok {
			println(val)
		} else {
			break
		}
	}
	println("over")
}
