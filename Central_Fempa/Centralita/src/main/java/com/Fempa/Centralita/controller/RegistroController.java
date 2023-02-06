package com.Fempa.Centralita.controller;

import com.Fempa.Centralita.model.Registro;
import com.Fempa.Centralita.model.Usuario;
import com.Fempa.Centralita.repository.RegistroRepository;
import com.Fempa.Centralita.repository.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/registros")
public class RegistroController {

    @Autowired
    private UsuarioRepository usuarioRepository;

    @Autowired
    private RegistroRepository registroRepository;

    @PostMapping
    public void createRegistro(@RequestBody Registro registro) {
        Usuario atendido_por = usuarioRepository.findById(registro.getAtendido_por().getId());
        Usuario empleado = usuarioRepository.findById(registro.getEmpleado().getId());
        registro.setAtendido_por(atendido_por);
        registro.setEmpleado(empleado);
        registroRepository.save(registro);
    }

    @GetMapping
    public @ResponseBody List<Registro> getRegistros() {
        return registroRepository.findAll();
    }


}